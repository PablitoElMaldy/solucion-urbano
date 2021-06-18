using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solucion_urbano.Models;


namespace solucion_urbano.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorContext _context;
        static bool leido = false;
        void  CargaDatos(){
            string[] lines = System.IO.File.ReadAllLines(@"db\palabras.txt");
            int contador = 1;
            foreach (string line in lines)
            {
                var reg = new Proveedor(contador,line);
                contador++;
                _context.Proveedor.Add(reg);
            }
            _context.SaveChanges();
        }
        public ProveedorController(ProveedorContext context)
        {
            _context = context;
            if(leido==false){
                CargaDatos();
                leido= true;
            }else{

            }
        }

        [HttpGet]
        public IEnumerable<Proveedor> GetProveedor(int cs = 0, int top=100, string query = "")
        {
            if(query== null || query.Trim().Equals("")){
                return new List<Proveedor>();
            }

            query = query.Replace("*", "%");
            query = query.Replace("?", "_");
            if(cs==1){
                 var proveedores = (from p in _context.Proveedor
                 where EF.Functions.Like(p.nombre, query)
                 select p).Take(top);
 
                    return proveedores;
            }
            else{
                 var proveedores = (from p in _context.Proveedor
                                where EF.Functions.Like(p.nombre.ToLower(), query.ToLower())
                select p).Take(top);

                return proveedores;
            }
        }
    }
    
}
