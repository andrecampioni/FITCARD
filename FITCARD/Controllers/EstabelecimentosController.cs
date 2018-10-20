using DAL.Entidades;
using DAL.Mensagem;
using DAL.Models;
using FITCARD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FITCARD.Controllers
{
    public class EstabelecimentosController : Controller
    {
        // GET: Estabelecimentos
        public ActionResult Index()
        {
            try
            {
                List<Estabelecimento> lista = EstabelecimentoDAL.Lista();
                return View(lista);
            }
            catch (Exception e)
            {
                TempData["Status"] = e.Message;
                return View();
            }
            
            
        }

        // GET: Estabelecimentos/Details/5
        public ActionResult Details(int id)
        {
            Estabelecimento cadastro = EstabelecimentoDAL.Obter(id);

            if(cadastro.IDEstabelecimento != 0)
            {
                return View(cadastro);
            }
            else
            {
                TempData["Status"] = 1;
                TempData["Message"] = "Estabelecimento não encontrado";
                return RedirectToAction("index");
            }
            
        }

        // GET: Estabelecimentos/Create
        public ActionResult Create()
        {
            Estabelecimento cadastro = new Estabelecimento();
            ViewBagCategoria();
            return View(cadastro);
        }

        // POST: Estabelecimentos/Create
        [HttpPost]
        public ActionResult Create(Estabelecimento cadastro)
        {

           if (ModelState.IsValid)
           {
               Retorno retorno = EstabelecimentoDAL.Inserir(cadastro);

                TempData["Status"] = retorno.IDRetorno;
                TempData["Message"] = retorno.Mensagem;
                                
                if (retorno.IDRetorno == 1)
                {
                    ViewBagCategoria();
                    return View(cadastro);
                }
           }

            return RedirectToAction("index");
        }

        // GET: Estabelecimentos/Edit/5
        public ActionResult Edit(int id)
        {
            Estabelecimento cadastro = EstabelecimentoDAL.Obter(id);

            if(cadastro.IDEstabelecimento != 0)
            {
                ViewBagCategoria();
                return View(cadastro);
            }
            else
            {
                TempData["Status"] = 1;
                TempData["Message"] = "Estabelecimento não encontrado";
                return RedirectToAction("index");
            }
            
        }

        // POST: Estabelecimentos/Edit/5
        [HttpPost]
        public ActionResult Edit(Estabelecimento cadastro)
        {
            if (ModelState.IsValid)
            {
                Retorno retorno = EstabelecimentoDAL.Atualizar(cadastro);

                TempData["Status"] = retorno.IDRetorno;
                TempData["Message"] = retorno.Mensagem;

                if (retorno.IDRetorno == 1)
                {
                    ViewBagCategoria();
                    return View(cadastro);
                }
            }

            return RedirectToAction("index");
        }

        // GET: Estabelecimentos/Delete/5
        public ActionResult Delete(int id)
        {
            Estabelecimento cadastro = EstabelecimentoDAL.Obter(id);

            if(cadastro.IDEstabelecimento != 0)
            {
                return View(cadastro);
            }
            else
            {
                TempData["Status"] = 1;
                TempData["Message"] = "Estabelecimento não encontrado";
                return RedirectToAction("Index");
            }
        }

        // POST: Estabelecimentos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
                Estabelecimento cadastro = EstabelecimentoDAL.Obter(id);

                if (cadastro != null)
                {
                    Retorno retorno = EstabelecimentoDAL.Excluir(cadastro.IDEstabelecimento);
                    TempData["Status"] = retorno.IDRetorno;
                    TempData["Message"] = retorno.Mensagem;

                    if (retorno.IDRetorno == 1)
                    {
                        return View(cadastro);
                    }

                }
                return RedirectToAction("Index");
        }

        public void ViewBagCategoria()
        {
            var lista = Enum.GetNames(typeof(Categoria.Categorias)).Cast<string>().ToList();

            ViewBag.Categorias = lista;

        }
    }
}
