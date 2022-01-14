using Santa_Maria.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Santa_Maria.Controllers
{
    public class ServicosController : Controller
    {
        public IActionResult CadastroDePecas() {   
            return View();
        }

        [HttpPost]
        public IActionResult CadastroDePecas(Servicos serv){
            
            ServicosRepository ser = new ServicosRepository();
            ser.Inserir(serv);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            return View();
        }
        public IActionResult ServicosResultado() {
 
            ServicosRepository xx = new ServicosRepository();
            List<Servicos> listaDeServicos = xx.Listar(); 
            return View(listaDeServicos);
         }
    }
}