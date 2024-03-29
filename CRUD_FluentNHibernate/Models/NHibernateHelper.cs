﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_FluentNHibernate.Models
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
            .ConnectionString(@"Data Source=.\SQLEXPRESS;Initial Catalog=NHIBERNATE;Integrated Security=True")
            .ShowSql()
            )
            .Mappings(m =>
            m.FluentMappings
            .AddFromAssemblyOf<Aluno>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg)
            .Create(false, false))
            .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
