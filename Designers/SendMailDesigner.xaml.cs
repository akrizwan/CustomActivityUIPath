using System;
using System.Activities.Presentation.Metadata;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomActivity
{
    // Interaction logic for SendMailDesigner.xaml
    public partial class SendMailDesigner
    {
        public SendMailDesigner()
        {
            InitializeComponent();
        }

        public static void RegisterMetadata(AttributeTableBuilder builder)
        {
            Type type = typeof(SendMail);
            builder.AddCustomAttributes(type, new DesignerAttribute(typeof(SendMailDesigner)));
            builder.AddCustomAttributes(type, type.GetProperty("To"), BrowsableAttribute.No);
            builder.AddCustomAttributes(type, type.GetProperty("From"), BrowsableAttribute.No);
            builder.AddCustomAttributes(type, type.GetProperty("Subject"), BrowsableAttribute.No);
            builder.AddCustomAttributes(type, type.GetProperty("Host"), BrowsableAttribute.No);
        }
    }
}
