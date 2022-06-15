using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {
        private UsuarioAdapter _UsuarioData;

        public UsuarioAdapter UsuarioData
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; }
        }

        public List<Usuario> GetAll()
        {
            var UsuarioData = new UsuarioAdapter();
            return UsuarioData.GetAll();
        }

        public Usuario GetOne(int id)
        {
            var UsuarioData = new UsuarioAdapter();
            return UsuarioData.GetOne(id);
        }

        public void Delete(int id)
        {
            var UsuarioData = new UsuarioAdapter();
            UsuarioData.Delete(id);
        }

        public void Save(Usuario usuario)
        {
            var UsuarioData = new UsuarioAdapter();
            UsuarioData.Save(usuario);
        }
    }
}
