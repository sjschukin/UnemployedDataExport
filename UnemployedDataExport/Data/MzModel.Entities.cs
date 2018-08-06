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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Data.Entity.Core;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;

namespace Schukin.UnemployedDataExport.Data
{
    public partial class Entities : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities() :
                base(@"name=Schukin.UnemployedDataExport.DataConnectionString")
        {
            Configure();
        }

        /// <summary>
        /// Initializes a new Entities object using the connection string found in the 'Entities' section of the application configuration file.
        /// </summary>
        public Entities(string nameOrConnectionString) :
                base(nameOrConnectionString)
        {
            Configure();
        }

        private void Configure()
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            throw new UnintentionalCodeFirstException();
        }

    
        /// <summary>
        /// Сведения о личности
        /// </summary>
        public virtual DbSet<Person> People { get; set; }
    
        /// <summary>
        /// Документы, удостоверяющие личность
        /// </summary>
        public virtual DbSet<IdentityDocument> IdentityDocuments { get; set; }
    
        /// <summary>
        /// Категории граждан
        /// </summary>
        public virtual DbSet<GlossaryCategory> GlossaryCategories { get; set; }
    
        /// <summary>
        /// Типы документов
        /// </summary>
        public virtual DbSet<GlossaryDocument> GlossaryDocuments { get; set; }
    }
}