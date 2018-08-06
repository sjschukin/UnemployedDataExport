using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Devart.Data.Oracle;
using NLog;
using Schukin.UnemployedDataExport.Data;
using Schukin.UnemployedDataExport.Properties;

namespace Schukin.UnemployedDataExport
{
    internal class Program
    {
        private static IOutput _output;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private static string _dbname;
        private static string _username;
        private static string _password;
        private static string _outputPath;
        private static int _versionFileNumber;
        private static bool _isUnicode;

        private static void Main(string[] args)
        {
            _output = new ConsoleOutput();

            if (args.Any(x => x == "/?"))
            {
                ShowHelp();
                return;
            }

            _dbname = GetParameterValue(args, "/db");
            _username = GetParameterValue(args, "/u");
            _password = GetParameterValue(args, "/p");
            _outputPath = GetParameterValue(args, "/o", Directory.GetCurrentDirectory());
            Int32.TryParse(GetParameterValue(args, "/vn", "0"), out _versionFileNumber);

            if (_versionFileNumber < 0 | _versionFileNumber > 99)
            {
                _versionFileNumber = 0;
            }

            _isUnicode = args.Contains("/unicode");

            if (String.IsNullOrEmpty(_dbname))
            {
                _output.Write("ОШИБКА: не указано имя базы данных.");
                _logger.Error("Заданы неверные параметры: не указано имя базы данных.");
                return;
            }

            if (String.IsNullOrEmpty(_username))
            {
                _output.Write("ОШИБКА: не указан логин пользователя базы данных.");
                _logger.Error("Заданы неверные параметры: не указан логин пользователя базы данных.");
                return;
            }

            DoWork();
        }

        public static void ShowHelp()
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName();
            var appName = assemblyName.Name;
            var version = assemblyName.Version;

            var lines = new[]
            {
                $"{appName}, версия {version}",
                "Формирование сведений о безработных гражданах для Министерства здравоохранения Рязанской области",
                "(см. описание формата файлов в Соглашении)",
                "(c) Министерство социальной защиты населения Рязанской области",
                "",
                "ИСПОЛЬЗОВАНИЕ:",
                "",
                $"  {appName}.exe " + "/db {db_name} /u {username} [/p {password}] [/o {path}] [/vn {number}] [/unicode]",
                "",
                "ПАРАМЕТРЫ:",
                "  /?            - отображает эту справку;",
                "  /db {db_name} - указывает имя базы данных, для сверки и выгрузки;",
                "  /u {username} - указывает логин для входа пользователя базы данных;",
                "  /p {password} - указывает пароль для входа пользователя базы данных;",
                "  /o {path}     - указывает путь к каталогу в который будет формироваться ответ;",
                "  /vn {number}   - порядковый номер выгрузки (только для имени файла) (0..99);",
                "  /unicode      - включает поддержку Unicode на стороне клиента."
            };

            _output.Write(lines);
        }

        private static string GetParameterValue(string[] args, string paramName)
        {
            if (args.All(x => x != paramName)) return null;

            string value = null;
            var index = Array.FindIndex(args, x => x == paramName);

            if (args.Length > index + 1)
                value = args[index + 1];

            return value;
        }

        private static string GetParameterValue(string[] args, string paramName, string defaultValue)
        {
            return GetParameterValue(args, paramName) ?? defaultValue;
        }

        private static string CreateConnectionString()
        {
            var conBuilder = new OracleConnectionStringBuilder
            {
                Server =_dbname,
                UserId = _username,
                Password = _password,
                Unicode = _isUnicode
            };

            var builder = new EntityConnectionStringBuilder
            {
                Provider = "Devart.Data.Oracle",
                ProviderConnectionString = conBuilder.ToString(),
                Metadata = "res://*/Data.MzModel.csdl|res://*/Data.MzModel.ssdl|res://*/Data.MzModel.msl"
            };

            return builder.ToString();
        }

        public static void DoWork()
        {
            try
            {
                _output.Write("Начало обработки...");
                _logger.Info("Начало обработки...");


                string filename = Settings.Default.SenderFileCode + DateTime.Now.ToString("yyMM") +
                                  _versionFileNumber.ToString().PadLeft(2, '0') + "000.xml";
                string outputFilename = Path.Combine(_outputPath, filename);

                var context = new Entities(CreateConnectionString()); //"Schukin.UnemployedDataExport.DataConnectionString"

                var persons = context.People
                    .Include(p => p.GlossaryCategory)
                    .Include(p => p.IdentityDocuments);

                var transferData = new TransferData
                {
                    version = 1.0m,
                    FileName = filename,
                    FileDescription = Settings.Default.FileDescription,
                    Created = DateTime.Now,
                    PartNumber = "0",
                    RecordsNumber = persons.Count().ToString(),
                    Sender = new TransferDataSender
                    {
                        Id = Settings.Default.SenderId,
                        Name = Settings.Default.SenderName
                    },
                    Recipient = new TransferDataRecipient
                    {
                        Id = Settings.Default.RecipientId,
                        Name = Settings.Default.RecipientName
                    }
                };

                var transferItems = new List<TransferDataPerson>();

                foreach (var person in persons)
                {
                    var transferPerson = new TransferDataPerson
                    {
                        Snils = person.Snils,
                        LastName = person.Lastname,
                        FirstName = person.Firstname,
                        SecondName = person.Secondname,
                        BirthDate = person.Birthdate,
                        Gender = person.Gender,
                        AddressBirth = new tAddress
                        {
                            AddressString = person.AddressBirthString,
                            AddressCode = person.AddressBirthAddresscode,
                            ZipCode = person.AddressBirthZipcode,
                            Country = person.AddressBirthCountry,
                            TerritorySubject = person.AddressBirthTerritorysubject,
                            District = person.AddressBirthDistrict,
                            Place = person.AddressBirthPlace,
                            Street = person.AddressBirthStreet,
                            House = person.AddressBirthHouse,
                            Building = person.AddressBirthBuilding,
                            Appartment = person.AddressBirthAppartment
                        },
                        AddressReg = new tAddress
                        {
                            AddressString = person.AddressRegString,
                            AddressCode = person.AddressRegAddresscode,
                            ZipCode = person.AddressRegZipcode,
                            Country = person.AddressRegCountry,
                            TerritorySubject = person.AddressRegTerritorysubject,
                            District = person.AddressRegDistrict,
                            Place = person.AddressRegPlace,
                            Street = person.AddressRegStreet,
                            House = person.AddressRegHouse,
                            Building = person.AddressRegBuilding,
                            Appartment = person.AddressRegAppartment
                        },
                        AddressFact = new tAddress
                        {
                            AddressString = person.AddressFactString,
                            AddressCode = person.AddressFactAddresscode,
                            ZipCode = person.AddressFactZipcode,
                            Country = person.AddressFactCountry,
                            TerritorySubject = person.AddressFactTerritorysubject,
                            District = person.AddressFactDistrict,
                            Place = person.AddressFactPlace,
                            Street = person.AddressFactStreet,
                            House = person.AddressFactHouse,
                            Building = person.AddressFactBuilding,
                            Appartment = person.AddressFactAppartment
                        },
                        IdentityDocuments = person.IdentityDocuments.Select(
                            item => new TransferDataPersonIdentityDocuments
                            {
                                Id = item.Id.ToString(),
                                Name = item.GlossaryDocument.Name,
                                Series = item.DocumentSeries,
                                Number = item.DocumentNumber,
                                IssueDate = item.DocumentIssuedate ?? new DateTime(1900, 1, 1),
                                Issuer = item.DocumentIssuer
                            }).ToArray(),
                        CategoryId = person.GlossaryCategory.Id.ToString(),
                        CategoryName = person.GlossaryCategory.Name
                    };

                    transferItems.Add(transferPerson);
                }

                transferData.Items = transferItems.ToArray();

                var serializer = new XmlSerializer(typeof(TransferData));

                using (var writer = XmlWriter.Create(outputFilename))
                {
                    serializer.Serialize(writer, transferData);
                }

                _output.Write($"Файл {filename} создан.");
                _logger.Info($"Файл {filename} создан.");
            }
            catch (OracleException ex)
            {
                _output.Write($"Ошибка базы данных: {ex.Message}");
                _logger.Error("Ошибка базы данных: {0}", ex);
            }
            catch (Exception ex)
            {
                _output.Write($"Ошибка: {ex.Message}");
                _logger.Error(ex);
            }
        }
    }
}
