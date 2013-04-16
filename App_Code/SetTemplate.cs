using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomDetailsView
{
    public class SetTemplate : ITemplate
    {
        private readonly DataControlRowType _dataControlRowType;
        private readonly string _columnName;

        /// <summary>
        /// Constructor for SetTemplate
        /// 
        /// this() -> automatically calls the overloaded constructor
        /// </summary>
        /// <param name="dataControlRowType"></param>
        public SetTemplate(DataControlRowType dataControlRowType) : this(dataControlRowType, string.Empty) { }

        /// <summary>
        /// Overload Constructor for SetTemplate
        /// </summary>
        /// <param name="dataControlRowType"></param>
        /// <param name="columnName"></param>
        public SetTemplate(DataControlRowType dataControlRowType, string columnName)
        {
            _dataControlRowType = dataControlRowType;
            _columnName = columnName;
        }


        public void InstantiateIn(Control container)
        {
            switch (_dataControlRowType)
            {
                case DataControlRowType.Header:
                    //Create new literal object
                    var header = new Literal
                                     {
                                         Text = string.Format("<b>{0}</b>", _columnName)
                                     };

                    //Add to container
                    container.Controls.Add(header);
                    break;

                case DataControlRowType.DataRow:

                    //Create new label object for First Name
                    var firstName = new Label();

                    //Set Databind Event for first name
                    firstName.DataBinding += FirstName_DataBinding;

                    //Add to container
                    container.Controls.Add(firstName);

                    //Add space between First Name and Last Name
                    var space = new Literal
                                    {
                                        Text = " "
                                    };

                    //Add to container
                    container.Controls.Add(space);

                    //Create new label object for Last Name
                    var lastName = new Label();

                    //Set Databind Event for first name
                    lastName.DataBinding += LastName_DataBinding;

                    //Add to container
                    container.Controls.Add(lastName);
                    break;
            }
        }

        private static void FirstName_DataBinding(object sender, EventArgs e)
        {
            //Set Label object
            var label = sender as Label;

            //Return if object sender is not a Label
            if (label == null)
                return;

            //Set container
            var container = label.NamingContainer as IDataItemContainer;

            //Return if container is null
            if (container == null)
                return;

            //Get data from bound datasource
            var data = DataBinder.Eval(container.DataItem, "FirstName");

            //Set data to label
            label.Text = data == null ? string.Empty : Convert.ToString(data);
        }

        private static void LastName_DataBinding(object sender, EventArgs e)
        {
            //Set Label object
            var label = sender as Label;

            //Return if object sender is not a Label
            if (label == null)
                return;

            //Set container
            var container = label.NamingContainer as IDataItemContainer;

            //Return if container is null
            if (container == null)
                return;

            //Get data from bound datasource
            var data = DataBinder.Eval(container.DataItem, "LastName");

            //Set data to label
            label.Text = data == null ? string.Empty : Convert.ToString(data);
        }
    }
}