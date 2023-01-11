using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PrestamoDeMaterial.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DBPath))]
namespace PrestamoDeMaterial.Droid
{
    public class DBPath : IDBPath
    {
        public string DBDir()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Prestamo.bd");
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            return path;
        }
    }
}