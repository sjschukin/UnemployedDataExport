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
    /// Документы, удостоверяющие личность
    /// </summary>
    public partial class IdentityDocument    {

        public IdentityDocument()
        {
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual int Id
        {
            get;
            set;
        }

    
        /// <summary>
        /// Идентификатор гражданина
        /// </summary>
        public virtual int PersonId
        {
            get;
            set;
        }

    
        /// <summary>
        /// Идентификатор типа документа
        /// </summary>
        public virtual int DocumentId
        {
            get;
            set;
        }

    
        /// <summary>
        /// Серия документа
        /// </summary>
        public virtual string DocumentSeries
        {
            get;
            set;
        }

    
        /// <summary>
        /// Номер документа
        /// </summary>
        public virtual string DocumentNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// Дата выдачи документа
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> DocumentIssuedate
        {
            get;
            set;
        }

    
        /// <summary>
        /// Наименование организации, выдавшей документ
        /// </summary>
        public virtual string DocumentIssuer
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Person in the schema.
        /// </summary>
        public virtual Person Person
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for GlossaryDocument in the schema.
        /// </summary>
        public virtual GlossaryDocument GlossaryDocument
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
