////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	form1.cs
//
// summary:	Implements the form 1 class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiViewer.WinForms
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A form 1. </summary>
    ///
    /// <remarks>   James Coates, 8/26/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class Form1 : Form
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnGo for click events. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnGo_Click(object sender, EventArgs e)
        {
            lstResults.DataSource = null;
            lstResults.Items.Clear();
            lstResults.DataSource = Standard.Apis.FactoryApi.Get(ddlApi.SelectedValue.ToString()).GetAll();
            lstResults.DisplayMember = "Name";

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by Form1 for load events. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            ddlCategory.DataSource = Standard.Apis.FactoryApi.GetCategories();
            ddlCategory.DisplayMember = "Value";

            ReloadApi();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///     Event handler. Called by ddlCategory for selected index changed events.
        /// </summary>
        ///
        /// <remarks>   James Coates, 8/27/2017. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadApi();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by ddlApi for selected index changed events. </summary>
        ///
        /// <remarks>   James Coates, 8/27/2017. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ddlApi_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstResults.DataSource = null;
            lstResults.Items.Clear();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reload API. </summary>
        ///
        /// <remarks>   James Coates, 8/27/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ReloadApi()
        {
            ddlApi.DataSource = null;
            ddlApi.Items.Clear();
            ddlApi.DataSource = ApiViewer.Standard.Apis.FactoryApi.GetApis(ddlCategory.SelectedValue.ToString());
            ddlApi.DisplayMember = "Value";
            ddlApi.ValueMember = "Key";
        }
    }
}
