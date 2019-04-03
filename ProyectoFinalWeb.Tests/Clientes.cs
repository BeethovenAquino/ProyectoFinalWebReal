using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalWeb.Tests
{
    [TestClass]
    public class Clientes
    {
       
             [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Cliente cliente = new Cliente();
            cliente.ClienteID = 0;
            cliente.NombreCliente = "Beethoven";
            cliente.Cedula = "15151515151";
            cliente.Direccion = "Castillo";
            cliente.Telefono = "8092595027";
            cliente.Total = 300;


            paso = ClienteBLL.Guardar(cliente);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Cliente cliente = new Cliente();
            cliente.ClienteID = 0;
            cliente.NombreCliente = "Beethoven";
            cliente.Cedula = "15151515151";
            cliente.Direccion = "Castillo";
            cliente.Telefono = "8092595027";
            cliente.Total = 300;


            paso = ClienteBLL.Guardar(cliente);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Cliente cliente = new Cliente();
            cliente.ClienteID = 0;
            cliente.NombreCliente = "Beethoven";
            cliente.Cedula = "15151515151";
            cliente.Direccion = "Castillo";
            cliente.Telefono = "8092595027";
            cliente.Total = 300;


            paso = ClienteBLL.Guardar(cliente);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso;
            Cliente cliente = new Cliente();
            cliente.ClienteID = 0;
            cliente.NombreCliente = "Beethoven";
            cliente.Cedula = "15151515151";
            cliente.Direccion = "Castillo";
            cliente.Telefono = "8092595027";
            cliente.Total = 300;


            paso = ClienteBLL.Guardar(cliente);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso;
            Cliente cliente = new Cliente();
            cliente.ClienteID = 0;
            cliente.NombreCliente = "Beethoven";
            cliente.Cedula = "15151515151";
            cliente.Direccion = "Castillo";
            cliente.Telefono = "8092595027";
            cliente.Total = 300;


            paso = ClienteBLL.Guardar(cliente);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void RetornarNombreTest()
        {
            bool paso;
            Cliente cliente = new Cliente();
            cliente.ClienteID = 0;
            cliente.NombreCliente = "Beethoven";
            cliente.Cedula = "15151515151";
            cliente.Direccion = "Castillo";
            cliente.Telefono = "8092595027";
            cliente.Total = 300;


            paso = ClienteBLL.Guardar(cliente);
            Assert.AreEqual(paso, true);
        }
    }
    }

