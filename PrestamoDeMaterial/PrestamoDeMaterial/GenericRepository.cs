using LiteDB;
using PrestamoDeMaterial.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PrestamoDeMaterial
{
    public class GenericRepository<T> where T : BaseDTO
    {
        LiteDatabase DB;
        LiteCollection<T> collection;
        public GenericRepository()
        {
            DB = new LiteDatabase(DependencyService.Get<IDBPath>().DBDir());
            collection = DB.GetCollection<T>(typeof(T).Name);

        }

        public string Error { get; private set; }

        public IEnumerable<T> Read
        {
            get
            {
                return collection.FindAll();
            }
        }

        public T Insert(T entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            entidad.FechaHora = DateTime.Now;
            try
            {
                Error = "";
                collection.Insert(entidad);
                return entidad;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public T Update(T entidad)
        {
            entidad.FechaHora = DateTime.Now;
            try
            {
                Error = "";
                return collection.Update(entidad) ? entidad : null;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }
        public bool Delete(T entidad)
        {
            try
            {
                bool r = collection.Delete(entidad.Id);
                Error = r ? "" : "Error al eliminar el elemento";
                return r;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        
    }
}

