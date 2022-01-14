using System.Collections.Generic;
using MySqlConnector;
using System;

namespace Santa_Maria.Models
{
    public class ServicosRepository
    {
         private const string DadosConexao = "DataBase=SantaMaria;Data Source=localhost;User Id=root";

        public void Inserir(Servicos serv){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);  

            Conexao.Open();

            String QuerySql = "insert into Servicos (Peca,Material) values (@Peca,@Material)";  

            MySqlCommand Comando = new MySqlCommand(QuerySql,Conexao); 

            Comando.Parameters.AddWithValue("@Peca",serv.Peca);
            Comando.Parameters.AddWithValue("@Material",serv.Material);
 
            Comando.ExecuteNonQuery(); 
            
            Conexao.Close();
        }
    
         public List<Servicos> Listar(){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);    

            Conexao.Open();

            String QuerySql = "select * from Servicos"; 
               
            MySqlCommand Comando = new MySqlCommand(QuerySql,Conexao); 

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Servicos> Lista = new List<Servicos>(); 

            while(Reader.Read()){ 

                Servicos ServicosEncontrados = new Servicos();
    
                ServicosEncontrados.Id = Reader.GetInt32("Id");

                    if (!Reader.IsDBNull(Reader.GetOrdinal("Peca"))) { 
                ServicosEncontrados.Peca = Reader.GetString("Peca"); }

                    if (!Reader.IsDBNull(Reader.GetOrdinal("Material"))) { 
                ServicosEncontrados.Material = Reader.GetString("Material"); }

                Lista.Add(ServicosEncontrados);
            }

            Conexao.Close();

            return Lista;   
        }
    
    }
}