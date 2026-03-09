using CleanArchitecture.PracticalTest.Domain.Common;
using CleanArchitecture.PracticalTest.Domain.Enums;
using CleanArchitecture.PracticalTest.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Domain.Entidades
{
    public class Paquete : BaseDomainModel
    {
        public decimal Peso { get; set; }
        public decimal Longitud { get; set; }
        public decimal Ancho { get; set; }
        public decimal Altura { get; set; }
        public EstatusPaquete Estatus { get; set; }
        public Guid? RutaId { get; set; }
        public Ruta Ruta { get; set; }
        public List<HistorialPaqueteEstatus> Historial { get; set; }

        public Paquete()
        {
            Historial = new List<HistorialPaqueteEstatus>();
        }
        public Paquete(decimal peso, decimal longitud, decimal ancho, decimal altura)
        {
            Validaciones(peso, longitud, ancho, altura);

            Id = Guid.NewGuid();
            Peso = peso;
            Longitud = longitud;
            Ancho = ancho;
            Altura = altura;
            Estatus = EstatusPaquete.Registrado;
            Historial = new List<HistorialPaqueteEstatus>();
        }
        private void Validaciones(decimal peso, decimal longitud, decimal ancho, decimal altura)
        {
            if (peso < 0.1m || peso > 50)
                throw new DomainException("El peso no está dentro del rango permitido");

            if(longitud > 150 || ancho > 150 || peso > 150)
                throw new DomainException("Dimensiones no válidas");

            var volume = longitud * ancho * altura;

            if (volume > 1000000)
                throw new DomainException("El volumen es mayor al permitido");
        }
        public void ActualizarEstatus(EstatusPaquete estatus, string motivo)
        {
            if (Estatus == EstatusPaquete.Entregado || Estatus == EstatusPaquete.Devuelto)
                throw new DomainException("No se puede cambiar el estatus de un paquete que fue entregado o devuelto.");

            bool transicionValida = Estatus switch
            {
                EstatusPaquete.Registrado => estatus == EstatusPaquete.EnBodega,
                EstatusPaquete.EnBodega => estatus == EstatusPaquete.EnTransito || estatus == EstatusPaquete.Devuelto,
                EstatusPaquete.EnTransito => estatus == EstatusPaquete.EnReparto || estatus == EstatusPaquete.Devuelto,
                EstatusPaquete.EnReparto => estatus == EstatusPaquete.Entregado || estatus == EstatusPaquete.Devuelto,
                _ => false
            };

            if (!transicionValida)
                throw new DomainException("Transacción de estado no permitida");

            Historial.Add(new HistorialPaqueteEstatus
            {
                Estatus = estatus,
                FechaDeCambioEstado = DateTime.UtcNow,
                Motivo = motivo
            });

            this.Estatus = estatus;
        }
        public void AsignarRuta(Ruta ruta)
        {
            if (Estatus != EstatusPaquete.EnBodega)
                throw new DomainException("Solo se puede asignar ruta si el paquete esta en Bodega");

            Ruta = ruta;

            ActualizarEstatus(EstatusPaquete.EnTransito, "Cambio de ruta");
        }
        public decimal CalcularCostoDeEnvio(decimal distanciaEnKm)
        {
            var costoBase = 50;
            var costoPeso = Math.Max(0, Peso - 1) * 15;
            var costoDistancia = distanciaEnKm * 2.5m;
            var subTotal = costoBase + costoPeso + costoDistancia;
            var volumen = Longitud * Ancho * Altura;
            
            return volumen > 500000 ? subTotal * 1.20m : subTotal;
        }
    }
}
