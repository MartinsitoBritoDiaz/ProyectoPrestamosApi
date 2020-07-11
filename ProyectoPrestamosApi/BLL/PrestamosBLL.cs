using Microsoft.EntityFrameworkCore;
using ProyectoPrestamosApi.DAL;
using ProyectoPrestamosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProyectoPrestamosApi.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Prestamos.Any(p => p.PrestamoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Insertar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                GuardarBalancePersona(prestamo);
                contexto.Prestamos.Add(prestamo);
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                ModificarBalancePersona(prestamo);
                contexto.Entry(prestamo).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamo;

            try
            {
                prestamo = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamo;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var prestamo = contexto.Prestamos.Find(id);

                if (prestamo != null)
                {
                    EliminarBalancePersona(prestamo);
                    contexto.Prestamos.Remove(prestamo);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> listaPrestamos = new List<Prestamos>();
            Contexto contexto = new Contexto();

            try
            {
                listaPrestamos = contexto.Prestamos.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaPrestamos;
        }


        /*Metodos para alterar el balance*/
        public static void GuardarBalancePersona(Prestamos prestamo)
        {
            Personas personas = new Personas();

            personas = PersonasBLL.Buscar(prestamo.PersonaId);
            personas.Balance += prestamo.Balance;

            PersonasBLL.Modificar(personas);
        }

        public static void ModificarBalancePersona(Prestamos prestamoNuevo)
        {
            Personas persona = new Personas();
            Prestamos prestamoAntiguo = new Prestamos();

            prestamoAntiguo = PrestamosBLL.Buscar(prestamoNuevo.PrestamoId);
            persona = PersonasBLL.Buscar(prestamoNuevo.PersonaId);

            persona.Balance -= prestamoAntiguo.Balance;
            persona.Balance += prestamoNuevo.Balance;

            PersonasBLL.Modificar(persona);
        }

        public static void EliminarBalancePersona(Prestamos prestamo)
        {
            Personas persona = new Personas();

            persona = PersonasBLL.Buscar(prestamo.PersonaId);
            persona.Balance -= prestamo.Balance;

            PersonasBLL.Modificar(persona);
        }

        public static List<Prestamos> GetPrestamo()
        {
            List<Prestamos> listaPrestamos = new List<Prestamos>();
            Contexto contexto = new Contexto();

            try
            {
                listaPrestamos = contexto.Prestamos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaPrestamos;
        }
    }
}
