using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Reflector2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string selectedFilePath;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Оберіть файл";
            openFileDialog.Filter = "Всі файли (*.*)|*.*|Текстові файли (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;
            }       
        }

        private void ShowAssemblyInfo()
        {
            InfoTextBox.Text = "";
            Assembly assembly = Assembly.LoadFrom(selectedFilePath);

            InfoTextBox.Text += "Ім'я складання:" + assembly.FullName + Environment.NewLine + Environment.NewLine;
            InfoTextBox.Text += $"Версія складання: {assembly.GetName().Version}" + Environment.NewLine;
            InfoTextBox.Text += $"Культура складання: {assembly.GetName().CultureInfo.DisplayName}" + Environment.NewLine;

            Type[] types = assembly.GetTypes();
            InfoTextBox.Text += $"Кількість типів у складанні: {types.Length}" + Environment.NewLine;
            InfoTextBox.Text += "Список типів:" + Environment.NewLine;

            if(MethodsCheckBox.IsChecked == true || AllCheckBox.IsChecked == true)
            {
                ShowMethodsInType(types);
            }
            if (PropertiesCheckBox.IsChecked == true || AllCheckBox.IsChecked == true)
            {
                ShowPropertiesInType(types);
            }
            if (FieldCheckBox.IsChecked == true || AllCheckBox.IsChecked == true)
            {
                ShowFieldsInType(types);
            }
            if (AttributesCheckBox.IsChecked == true || AllCheckBox.IsChecked == true)
            {
                ShowAttributesInType(assembly);
            }
            if (ConstructorsCheckBox.IsChecked == true || AllCheckBox.IsChecked == true)
            {
                ShowConstructorsInType(types);
            }
            if (EventCheckBox.IsChecked == true || AllCheckBox.IsChecked == true)
            {
                ShowEventsInType(types);
            }
        }

        public void ShowMethodsInType(Type[] types)
        {
            InfoTextBox.Text += Environment.NewLine + $"Методи:" + Environment.NewLine;

            foreach (Type item in types)
            {
                InfoTextBox.Text += $"- {item.FullName}" + Environment.NewLine;

                MethodInfo[] methods = item.GetMethods();
                InfoTextBox.Text += $"  Кількість методів у типі {item.FullName}: {methods.Length}" + Environment.NewLine;
                InfoTextBox.Text += "  Список методів:" + Environment.NewLine;
                foreach (MethodInfo method in methods)
                {
                    InfoTextBox.Text += $"    - {method.Name}. Тип: {method.ReturnType}" + Environment.NewLine;
                }
            }
        }

        public void ShowPropertiesInType(Type[] types)
        {
            InfoTextBox.Text += Environment.NewLine + $"Властивості:" + Environment.NewLine;
            foreach (Type item in types)
            {
                InfoTextBox.Text += $"- {item.FullName}" + Environment.NewLine;

                PropertyInfo[] properties = item.GetProperties();
                InfoTextBox.Text += $"  Кількість властивостей у типі {item.FullName}: {properties.Length}" + Environment.NewLine;
                InfoTextBox.Text += "  Список властивостей:" + Environment.NewLine;
                foreach (PropertyInfo property in properties)
                {
                    InfoTextBox.Text += $"    - {property.Name}. Тип: {property.PropertyType}" + Environment.NewLine;
                }
            }
        }

        public void ShowFieldsInType(Type[] types)
        {
            InfoTextBox.Text += Environment.NewLine + $"Поля:" + Environment.NewLine;
            foreach (Type item in types)
            {
                InfoTextBox.Text += $"- {item.FullName}" + Environment.NewLine;

                FieldInfo[] fields = item.GetFields();
                InfoTextBox.Text += $"  Кількість полей у типі {item.FullName}: {fields.Length}" + Environment.NewLine;
                InfoTextBox.Text += "  Список полей:" + Environment.NewLine;
                foreach (FieldInfo field in fields)
                {
                    InfoTextBox.Text += $"    - {field.Name}. Тип: {field.FieldType}" + Environment.NewLine;
                }
            }
        }

        public void ShowAttributesInType(Assembly assembly)
        {
            InfoTextBox.Text += Environment.NewLine + $"Атрибути сборки:" + Environment.NewLine;
            object[] assemblyAttributes = assembly.GetCustomAttributes(true);
            foreach (var attribute in assemblyAttributes)
            {
                InfoTextBox.Text += $"    - Атрибут: {attribute}" + Environment.NewLine;
            }
        }

      
        public void ShowConstructorsInType(Type[] types)
        {
            InfoTextBox.Text += Environment.NewLine + $"Конструктори:" + Environment.NewLine;
            foreach (Type item in types)
            {
                InfoTextBox.Text += $"- {item.FullName}" + Environment.NewLine;

                ConstructorInfo[] constructors = item.GetConstructors();
                InfoTextBox.Text += $"  Кількість конструкторів у типі {item.FullName}: {constructors.Length}" + Environment.NewLine;
                InfoTextBox.Text += "  Список конструкторів:" + Environment.NewLine;
                foreach (ConstructorInfo constructor in constructors)
                {
                    InfoTextBox.Text += $"    - {constructor.Name}." + Environment.NewLine;
                }
            }
        }

        public void ShowEventsInType(Type[] types)
        {
            InfoTextBox.Text += Environment.NewLine + $"Події:" + Environment.NewLine;
            foreach (Type item in types)
            {
                InfoTextBox.Text += $"- {item.FullName}" + Environment.NewLine;

                EventInfo[] events = item.GetEvents();
                InfoTextBox.Text += $"  Кількість подій у типі {item.FullName}: {events.Length}" + Environment.NewLine;
                InfoTextBox.Text += "  Список подій:" + Environment.NewLine;
                foreach (EventInfo ev in events)
                {
                    InfoTextBox.Text += $"    - {ev.Name}." + Environment.NewLine;
                }
            }
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedFilePath == null)
                    throw new Exception();

                ShowAssemblyInfo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }              
        }
    }
}
