using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albergue.Data.Entities;
using MySql.Data.MySqlClient;


namespace Albergue.Data.Repository
{
    public class Refuge : IRefuge
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=albergues;";
        static string query = "SELECT * FROM pets";



        private List<PetEntity> pets = new List<PetEntity>(){
            new PetEntity(){Id=1,Name="Negrito",Sex='H',Description="Perrito color negro muy cariñoso"},
            new PetEntity(){Id=2,Name="Pelusa",Sex='M',Description="Perrito muy cariñoso"},
            new PetEntity(){Id=3,Name="Chocolate",Sex='M',Description="Perrito divertido"},
            new PetEntity(){Id=4,Name="Lola",Sex='H',Description="Sabe lamer"} };

        public IEnumerable<PetEntity> GetPets()
        {
            List<PetEntity> pets = new List<PetEntity>();
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();
            MySqlDataReader _reader= commandDatabase.ExecuteReader();
            if (_reader.HasRows)
            {
                while (_reader.Read())
                {
                    PetEntity pet = new PetEntity();
                    pet.Id = _reader.GetInt32(0);
                    pet.Name = _reader.GetString(1);
                    pet.Sex = _reader.GetChar(2);
                    pet.Description = _reader.GetString(3);
                    pets.Add(pet);
                }
                databaseConnection.Close();
            }
            return pets;
        }

        public PetEntity GetPet(int petId)
        {
            PetEntity pet = new PetEntity();
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            string query = $"SELECT * FROM pets where Id = {petId}";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();
            MySqlDataReader _reader = commandDatabase.ExecuteReader();
            if (_reader.HasRows)
            {
                while (_reader.Read())
                {
                    
                    pet.Id = _reader.GetInt32(0);
                    pet.Name = _reader.GetString(1);
                    pet.Sex = _reader.GetChar(2);
                    pet.Description = _reader.GetString(3);
                }
                databaseConnection.Close();
            }
            return pet;
        }
        public PetEntity CreatePet(PetEntity petEntity)
        {
            int retorno = 0;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            MySqlCommand commandDatabase = new MySqlCommand($"Insert into  pets(Name, Sex, Description) values( '{petEntity.Name}','{petEntity.Sex}', '{petEntity.Description}' )", databaseConnection);
            retorno = commandDatabase.ExecuteNonQuery();
            databaseConnection.Close();
            return petEntity;
        }

        public bool DeletePet(int petId)
        {
            int retorno = 0;
            bool res = false;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            string query = $"Delete From pets where Id ={ petId }";
            MySqlCommand commandDatabase = new MySqlCommand(query,databaseConnection);
            retorno = commandDatabase.ExecuteNonQuery();
            databaseConnection.Close();
            if (retorno==1)
                res = true;
            return res;          
        }

        public PetEntity UpdatePet(PetEntity petEntity)
        {
            int retorno = 0;

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            MySqlCommand comando = new MySqlCommand($"Update pets set Name = '{petEntity.Name}', Sex='{ petEntity.Sex }', Description = '{petEntity.Description}' where Id = { petEntity.Id }", databaseConnection);

            retorno = comando.ExecuteNonQuery();

            databaseConnection.Close();

            return petEntity;
            /*
            var petToUpdate = GetPet(petEntity.Id);
            petToUpdate.Name = petEntity.Name ?? petToUpdate.Name;
            petToUpdate.Sex = petEntity.Sex ?? petToUpdate.Sex;
            petToUpdate.Description = petEntity.Description ?? petToUpdate.Description;
            return petToUpdate;*/
        }
    }
}
