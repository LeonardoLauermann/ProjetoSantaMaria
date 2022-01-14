using Santa_Maria.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Santa_Maria.Controllers
{
    public class TrabalheConoscoController : Controller
    {
            public IActionResult TrabalheConosco() {   
            return View();
        }

        [HttpPost]
        public IActionResult TrabalheConosco(TrabalheConosco trab){
            
            TrabalheConoscoRepository tra = new TrabalheConoscoRepository();
            tra.Inserir(trab);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            return View();
        }
        public IActionResult TrabalheConoscoResultados() {   
            TrabalheConoscoRepository tra = new TrabalheConoscoRepository();
            List<TrabalheConosco> listaDeCurriculos = tra.Listar(); 
            return View(listaDeCurriculos);
         }
    }
}