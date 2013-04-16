using System.Web.UI.WebControls;

namespace CustomDetailsView
{
    /// <summary>
    /// Summary description for DetailsViewControl
    /// </summary>
    public class DetailsViewControl : CompositeControl
    {
        private DetailsView _detailsView;
        private readonly TestDataList _list = new TestDataList();

        protected override void CreateChildControls()
        {
            _detailsView = new DetailsView
            {
                ID = string.Format("{0}_detailsView", base.ID),
                AutoGenerateRows = false,
                AllowPaging = true
            };

            //Set Paging Events
            _detailsView.PageIndexChanging += DetailsView_PageIndexChanging;

            //Create Custom Field
            var customField = new TemplateField
            {
                HeaderTemplate = new SetTemplate(DataControlRowType.Header, "Name"),
                ItemTemplate = new SetTemplate(DataControlRowType.DataRow)
            };

            //Add custom field to detailsview field
            _detailsView.Fields.Add(customField);

            //Create Bound Field
            var boundField = new BoundField
            {
                DataField = "PhoneNumber",
                HeaderText = "Phone Number",
            };

            //Set header font to bold
            boundField.HeaderStyle.Font.Bold = true;

            //Add bound field to detailsview field
            _detailsView.Fields.Add(boundField);

            //Bind Details View
            DetailsView_DataBind();

            //Add detaisview to composite control
            Controls.Add(_detailsView);
        }

        private void DetailsView_DataBind()
        {
            //Set datasource (IList, DataTable, DataView, LINQ Object)
            _detailsView.DataSource = _list;

            //Bind gridview
            _detailsView.DataBind();
        }

        private void DetailsView_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            //Set Page Index to New Page Index
            _detailsView.PageIndex = e.NewPageIndex;

            //Bind Details View
            DetailsView_DataBind();

        }
    }
}