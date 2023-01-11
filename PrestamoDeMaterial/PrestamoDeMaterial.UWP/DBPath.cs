using PrestamoDeMaterial.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(DBPath))]
namespace PrestamoDeMaterial.UWP
{
    public class DBPath : IDBPath
    {
        public string DBDir()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, "Prestamo.db");
        }
    }
}
