using AssemblyInfo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModelAB
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private Loader loader = new Loader();
        private Assembly _assembly;
        private ObservableCollection<Node> _nodes;
        public ObservableCollection<Node> Nodes
        {
            get { return _nodes; }
            set
            {
                _nodes = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Node> NamespacesToObservableCollection(Dictionary<string, NamespaceInfo> namespaces)
        {
            var collection = new ObservableCollection<Node>();
            foreach (var nspace in namespaces)
            {
                collection.Add(new Node(nspace.Value.ToString(), TypesToObservableCollection(nspace.Value.Types)));
            }
            return collection;
        }

        private ObservableCollection<Node> TypesToObservableCollection(List<TypeInfo> types)
        {
            var collection = new ObservableCollection<Node>();
            foreach(var type in types)
            {
                collection.Add(new Node(type.ToString(), MembersToObservableCollection(type)));
            }
            return collection;
        }

        private ObservableCollection<Node> MembersToObservableCollection(TypeInfo type)
        {
            var collection = new ObservableCollection<Node>();
            foreach (var method in type.Methods)
            {
                collection.Add(new Node(method.ToString()));
            }
            foreach (var property in type.Properties)
            {
                collection.Add(new Node(property.ToString()));
            }
            foreach (var field in type.Fields)
            {
                collection.Add(new Node(field.ToString()));
            }
            return collection;
        }
        public void OpenAssembly(object o, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter += "Dll files(*.dll)|*.dll";
            if (fileDialog.ShowDialog() == false)
                return;
            _assembly = loader.Load(fileDialog.FileName);
            Nodes = new ObservableCollection<Node>
            {
                new Node(_assembly.ToString(), NamespacesToObservableCollection(_assembly.Namespaces))
            };

        }

    }
}
