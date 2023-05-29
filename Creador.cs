using System;
using System.IO;

namespace cajero
{
    abstract class Creator
    {
        public abstract IOperacion FactoryMethod();
        
        public string SomeOperation()
        {
            var product = FactoryMethod();
            var result = "Se ha realizado la operación: "
                + product.Operation();
            
            return result;
        }
        
    }

    class ConsultaSaldoCreator : Creator
    {
        public override IOperacion FactoryMethod()
        {
            return new ConsultaSaldo();
        }
    }

    class RetirosCreator : Creator
    {
        public override IOperacion FactoryMethod()
        {
            return new Retiros();
        }
    }
    class TransferenciasCreator : Creator
    {
        public override IOperacion FactoryMethod()
        {
            return new Transferencias();
        }
    }
    class ConsultaPuntosCreator : Creator
    {
        public override IOperacion FactoryMethod()
        {
            return new ConsultaPuntos();
        }
    }
    class CanjePuntosCreator : Creator
    {
        public override IOperacion FactoryMethod()
        {
            return new CanjePuntos();
        }
    }
}