using appLoginASPCORE.Models;
using Newtonsoft.Json;


namespace appLoginASPCORE.Libraries.Sessao
{
    public class Sessao
    {
        IHttpContextAccessor _context;

        public Sessao (IHttpContextAccessor context)
        {
            _context = context;
        }

        public void Cadastrar(string key, string Valor)
        {
            _context.HttpContext.Session.SetString(key, Valor);
        }

        public string Consultar(string key)
        {
            return _context.HttpContext.Session.GetString(key);
        }

        public bool Existe (string key)
        {
            if (_context.HttpContext.Session.GetString(key) == null)
            {
                return false;
            }
            return true;
        }
        public void Remover (string key)
        {
            _context.HttpContext.Session.Remove(key);
        }
        public void RemoverTodos()
        {
            _context.HttpContext.Session.Clear();
        }
        public void Atualizar(string key, string valor)
        {
            if (Existe(key))
            {
                _context.HttpContext.Session.Remove(key);
            }
            _context.HttpContext.Session.SetString (key, valor);   

        }   

    }
}
