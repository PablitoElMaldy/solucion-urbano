namespace solucion_urbano.Models
{
    public class Proveedor
    {
        public int id {get;set;}
        public string nombre {get;set;}

        public Proveedor(int id, string nombre){
            this.id= id;
            this.nombre = nombre;
        }
    }
}