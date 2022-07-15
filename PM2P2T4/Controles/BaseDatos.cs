using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2P2T4.Models;
using System.Threading.Tasks;

namespace PM2P2T4.Controles
{
   public  class BaseDatos
    {
        readonly SQLiteAsyncConnection db;

        public BaseDatos(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);

            db.CreateTableAsync<Fotos>().Wait();
        }

        
        public Task<List<Fotos>> getListVideos()
        {
            return db.Table<Fotos>().ToListAsync();
        }

       
        public Task<Fotos> getVideoBycodigo(int codigoParam)
        {
            return db.Table<Fotos>()
                .Where(i => i.codigo == codigoParam)
                .FirstOrDefaultAsync();
        }

        
        public Task<int> saveVideo(Fotos Fotos)
        {
            if (Fotos.codigo != 0)
            {
                return db.UpdateAsync(Fotos);
            }
            else
            {
                return db.InsertAsync(Fotos);
            }

        }

        public Task<int> deleteVideo(Fotos Fotos)
        {
            return db.DeleteAsync(Fotos);
        }
    }
}

