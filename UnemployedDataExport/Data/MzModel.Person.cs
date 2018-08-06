﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 24.07.2017 11:17:24
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Schukin.UnemployedDataExport.Data
{

    /// <summary>
    /// Сведения о личности
    /// </summary>
    public partial class Person    {

        public Person()
        {
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public virtual int Id
        {
            get;
            set;
        }

    
        /// <summary>
        /// СНИЛС
        /// </summary>
        public virtual string Snils
        {
            get;
            set;
        }

    
        /// <summary>
        /// Фамилия
        /// </summary>
        public virtual string Lastname
        {
            get;
            set;
        }

    
        /// <summary>
        /// Имя
        /// </summary>
        public virtual string Firstname
        {
            get;
            set;
        }

    
        /// <summary>
        /// Отчество
        /// </summary>
        public virtual string Secondname
        {
            get;
            set;
        }

    
        /// <summary>
        /// Дата рождения
        /// </summary>
        public virtual global::System.DateTime Birthdate
        {
            get;
            set;
        }

    
        /// <summary>
        /// Пол
        /// </summary>
        public virtual string Gender
        {
            get;
            set;
        }

    
        /// <summary>
        /// Место рождения - Строка адреса
        /// </summary>
        public virtual string AddressBirthString
        {
            get;
            set;
        }

    
        /// <summary>
        /// Место рождения - Код адреса КЛАДР
        /// </summary>
        public virtual string AddressBirthAddresscode
        {
            get;
            set;
        }

    
        /// <summary>
        /// Место рождения - Почтовый индекс
        /// </summary>
        public virtual string AddressBirthZipcode
        {
            get;
            set;
        }

    
        /// <summary>
        /// Место рождения - Страна
        /// </summary>
        public virtual string AddressBirthCountry
        {
            get;
            set;
        }

    
        /// <summary>
        /// Место рождения - Субъект РФ
        /// </summary>
        public virtual string AddressBirthTerritorysubject
        {
            get;
            set;
        }

    
        /// <summary>
        /// Место рождения - Район
        /// </summary>
        public virtual string AddressBirthDistrict
        {
            get;
            set;
        }

    
        /// <summary>
        /// Место рождения - Населенный пункт
        /// </summary>
        public virtual string AddressBirthPlace
        {
            get;
            set;
        }

    
        /// <summary>
        /// Место рождения - Улица
        /// </summary>
        public virtual string AddressBirthStreet
        {
            get;
            set;
        }

    
        /// <summary>
        /// Место рождения - Дом
        /// </summary>
        public virtual string AddressBirthHouse
        {
            get;
            set;
        }

    
        /// <summary>
        /// Место рождения - Корпус
        /// </summary>
        public virtual string AddressBirthBuilding
        {
            get;
            set;
        }

    
        /// <summary>
        /// Место рождения - Квартира
        /// </summary>
        public virtual string AddressBirthAppartment
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес регистрации - Строка адреса
        /// </summary>
        public virtual string AddressRegString
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес регистрации - Код адреса КЛАДР
        /// </summary>
        public virtual string AddressRegAddresscode
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес регистрации - Почтовый индекс
        /// </summary>
        public virtual string AddressRegZipcode
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес регистрации - Страна
        /// </summary>
        public virtual string AddressRegCountry
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес регистрации - Субъект РФ
        /// </summary>
        public virtual string AddressRegTerritorysubject
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес регистрации - Район
        /// </summary>
        public virtual string AddressRegDistrict
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес регистрации - Населенный пункт
        /// </summary>
        public virtual string AddressRegPlace
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес регистрации - Улица
        /// </summary>
        public virtual string AddressRegStreet
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес регистрации - Дом
        /// </summary>
        public virtual string AddressRegHouse
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес регистрации - Корпус
        /// </summary>
        public virtual string AddressRegBuilding
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес регистрации - Квартира
        /// </summary>
        public virtual string AddressRegAppartment
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес фактического проживания - Строка адреса
        /// </summary>
        public virtual string AddressFactString
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес фактического проживания - Код адреса КЛАДР
        /// </summary>
        public virtual string AddressFactAddresscode
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес фактического проживания - Почтовый индекс
        /// </summary>
        public virtual string AddressFactZipcode
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес фактического проживания - Страна
        /// </summary>
        public virtual string AddressFactCountry
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес фактического проживания - Субъект РФ
        /// </summary>
        public virtual string AddressFactTerritorysubject
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес фактического проживания - Район
        /// </summary>
        public virtual string AddressFactDistrict
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес фактического проживания - Населенный пункт
        /// </summary>
        public virtual string AddressFactPlace
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес фактического проживания - Улица
        /// </summary>
        public virtual string AddressFactStreet
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес фактического проживания - Дом
        /// </summary>
        public virtual string AddressFactHouse
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес фактического проживания - Корпус
        /// </summary>
        public virtual string AddressFactBuilding
        {
            get;
            set;
        }

    
        /// <summary>
        /// Адрес фактического проживания - Квартира
        /// </summary>
        public virtual string AddressFactAppartment
        {
            get;
            set;
        }

    
        /// <summary>
        /// Идентификатор категории личности
        /// </summary>
        public virtual int CategoryId
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for IdentityDocuments in the schema.
        /// </summary>
        public virtual ICollection<IdentityDocument> IdentityDocuments
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for GlossaryCategory in the schema.
        /// </summary>
        public virtual GlossaryCategory GlossaryCategory
        {
            get;
            set;
        }

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
