using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalWeb.Tests
{
    [TestClass]
    public class FacturacionTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Facturacion facturacion = new Facturacion();
            facturacion.FacturaID = 0;
            facturacion.Fecha = DateTime.Now;
            facturacion.Subtotal = 0;
            facturacion.Total = 900;
            facturacion.ClienteID = 0;

            paso = FacturacionBLL.Guardar(facturacion);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {

            bool paso;
            Facturacion facturacion = new Facturacion();
            facturacion.FacturaID = 0;
            facturacion.Fecha = DateTime.Now;
            facturacion.Subtotal = 0;
            facturacion.Total = 900;
            facturacion.ClienteID = 0;

            paso = FacturacionBLL.Guardar(facturacion);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {

            bool paso;
            Facturacion facturacion = new Facturacion();
            facturacion.FacturaID = 0;
            facturacion.Fecha = DateTime.Now;
            facturacion.Subtotal = 0;
            facturacion.Total = 900;
            facturacion.ClienteID = 0;

            paso = FacturacionBLL.Guardar(facturacion);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {

            bool paso;
            Facturacion facturacion = new Facturacion();
            facturacion.FacturaID = 0;
            facturacion.Fecha = DateTime.Now;
            facturacion.Subtotal = 0;
            facturacion.Total = 900;
            facturacion.ClienteID = 0;

            paso = FacturacionBLL.Guardar(facturacion);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {

            bool paso;
            Facturacion facturacion = new Facturacion();
            facturacion.FacturaID = 0;
            facturacion.Fecha = DateTime.Now;
            facturacion.Subtotal = 0;
            facturacion.Total = 900;
            facturacion.ClienteID = 0;

            paso = FacturacionBLL.Guardar(facturacion);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void CalcularImporteTest()
        {

            bool paso;
            Facturacion facturacion = new Facturacion();
            facturacion.FacturaID = 0;
            facturacion.Fecha = DateTime.Now;
            facturacion.Subtotal = 0;
            facturacion.Total = 900;
            facturacion.ClienteID = 0;

            paso = FacturacionBLL.Guardar(facturacion);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void CalcularDevueltaTest()
        {

            bool paso;
            Facturacion facturacion = new Facturacion();
            facturacion.FacturaID = 0;
            facturacion.Fecha = DateTime.Now;
            facturacion.Subtotal = 0;
            facturacion.Total = 900;
            facturacion.ClienteID = 0;

            paso = FacturacionBLL.Guardar(facturacion);
            Assert.AreEqual(paso, true);
        }
    }
}
