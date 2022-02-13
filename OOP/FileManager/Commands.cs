using System;

namespace FileManager
{
    public abstract class Commands
    {
        public abstract void Add();
        public abstract void Remove();
        public abstract void GetInfo();
        public abstract void Rename();
        public abstract void Copy();
        public abstract void Move();
    }
}
