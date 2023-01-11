using PrestamoDeMaterial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestamoDeMaterial
{
    public class PrestamoManager
    {
        GenericRepository<Prestamo> prestamoRepository;
        public PrestamoManager()
        {
            prestamoRepository = new GenericRepository<Prestamo>();
        }

        public string Error { get; private set; }

        public IEnumerable<Prestamo> ObtenerTodos
        {
            get
            {
                return prestamoRepository.Read.OrderBy(e=>e.Estado);
            }
        }

        public Prestamo AgregarPrestamo(Prestamo prestamo)
        {
            try
            {
                Prestamo r = prestamoRepository.Insert(prestamo);
                Error = r != null ? "" : prestamoRepository.Error;
                return r;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public Prestamo EditarPrestamo(Prestamo prestamo)
        {
            try
            {
                Prestamo r = prestamoRepository.Update(prestamo);
                Error = r != null ? "" : prestamoRepository.Error;
                return r;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public bool EliminarPrestamo(Prestamo prestamo)
        {
            try
            {
                bool r = prestamoRepository.Delete(prestamo);
                Error = r ? "" : prestamoRepository.Error;
                return r;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public IEnumerable<Prestamo> PrestamosPorEntregar
        {
            get
            {
                return prestamoRepository.Read.Where(p => !p.Entregado).OrderByDescending(f=>f.RetornoEstimado);
            }
        }

        public IEnumerable<Prestamo> PrestamosEntregados
        {
            get
            {
                return prestamoRepository.Read.Where(p => p.Entregado).OrderByDescending(f => f.FechaHoraPrestamo);
            }
        }
        #region OtrosMetodosNoImplementados
        //public IEnumerable<Prestamo> PrestamosDeAlumnoPorEntregar(string matricula)
        //{
        //    return prestamoRepository.Read.Where(p => p.Matricula == matricula && !p.Entregado).OrderByDescending(f => f.RetornoEstimado);
        //}

        //public IEnumerable<Prestamo> TodosLosPrestamosDeAlumno(string matricula)
        //{
        //    return prestamoRepository.Read.Where(p => p.Matricula == matricula);
        //}

        //public IEnumerable<Prestamo> BuscarMaterialEnNoEntregados(string material)
        //{
        //    return PrestamosPorEntregar.Where(p => p.ContieneMaterial(material));
        //}
        #endregion
    }
}
