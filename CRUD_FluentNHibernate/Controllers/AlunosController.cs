using CRUD_FluentNHibernate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using System.Web;
using ISession = NHibernate.ISession;

namespace CRUD_FluentNHibernate.Controllers
{
    public class AlunosController : Controller
    {
        // GET: AlunosController
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
            {
                var alunos = session.Query<Aluno>().ToList();
                return View(alunos);
            }

        }

        // GET: AlunosController/Details/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }
        }

        // GET: AlunosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlunosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(aluno);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunosController/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }
        }

        // POST: AlunosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var alunoAlterado = session.Get<Aluno>(id);
                    alunoAlterado.Sexo = aluno.Sexo;
                    alunoAlterado.Curso = aluno.Curso;
                    alunoAlterado.Email = aluno.Email;
                    alunoAlterado.Nome = aluno.Nome;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(alunoAlterado);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunosController/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }
        }

        // POST: AlunosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(aluno);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
