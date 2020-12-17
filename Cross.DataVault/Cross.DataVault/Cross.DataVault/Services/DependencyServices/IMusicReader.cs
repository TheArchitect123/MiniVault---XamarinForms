using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Services.DependencyServices
{
    public interface IMusicReader
    {
        //POST
        void AddMusic<Music>() where Music : IMusic;
        void AddMusic<Music>(List<Music> cols) where Music : IMusic;

        //GET
        Music GetMusic<Music>() where Music : IMusic;
        List<Music> GetMusic_Collection<Music>() where Music : IMusic;
        List<Music> GetMusic_CollectionFromTime<Music>(DateTime ReferenceDate) where Music : IMusic; 
    }
}
