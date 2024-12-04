using appLoginASPCORE.Models;
using Newtonsoft.Json;

namespace appLoginASPCORE.Libraries.Login
{
    public class LoginCliente
    {
        private string key = "Login.Cliente";
        private Sessao.Sessao _sessao;
        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            //serializer

            string clienteJSONString = JsonConvert.SerializeObject(cliente);

            _sessao.Cadastrar(key, clienteJSONString);
        }

        public Cliente GetCliente()
        {
            if (_sessao.Existe(key))
            {
                string clienteJSONString = _sessao.Consultar(key);
                return JsonConvert.DeserializeObject<Cliente>(clienteJSONString);
            }
            else
            {
                return null;
            }
        }
        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}   
