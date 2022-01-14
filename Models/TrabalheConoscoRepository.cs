using System.Collections.Generic;
using MySqlConnector;
using System;

namespace Santa_Maria.Models
{
    public class TrabalheConoscoRepository
    {
         private const string DadosConexao = "DataBase=SantaMaria;Data Source=localhost;User Id=root";

         
        public void Inserir(TrabalheConosco trab){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);  

            Conexao.Open();

            String QuerySql = "insert into TrabalheConosco (NomeCompleto,Numero,Email) values (@NomeCompleto,@Numero,@Email)";  

            MySqlCommand Comando = new MySqlCommand(QuerySql,Conexao); 

            Comando.Parameters.AddWithValue("@NomeCompleto",trab.NomeCompleto);
            Comando.Parameters.AddWithValue("@Numero",trab.Numero);
            Comando.Parameters.AddWithValue("@Email",trab.Email);
 
            Comando.ExecuteNonQuery(); 
            
            Conexao.Close();
        }
    
         public List<TrabalheConosco> Listar(){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);    

            Conexao.Open();

            String QuerySql = "select * from TrabalheConosco"; 
               
            MySqlCommand Comando = new MySqlCommand(QuerySql,Conexao); 

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<TrabalheConosco> Lista = new List<TrabalheConosco>(); 

            while(Reader.Read()){ 

                TrabalheConosco CurriculosEncontrados = new TrabalheConosco();
    
                CurriculosEncontrados.Id = Reader.GetInt32("Id");

                    if (!Reader.IsDBNull(Reader.GetOrdinal("NomeCompleto"))) { 
                CurriculosEncontrados.NomeCompleto = Reader.GetString("NomeCompleto"); }

                    if (!Reader.IsDBNull(Reader.GetOrdinal("Email"))) { 
                CurriculosEncontrados.Email = Reader.GetString("Email"); }

                CurriculosEncontrados.Numero = Reader.GetInt32("Numero");

                Lista.Add(CurriculosEncontrados);
            }

            Conexao.Close();

            return Lista;   
        }
    }
}