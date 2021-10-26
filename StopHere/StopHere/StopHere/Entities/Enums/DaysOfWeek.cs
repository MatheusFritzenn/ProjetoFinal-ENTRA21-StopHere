using System;

namespace Entities.Enums
{
    [Flags]
    public enum DaysOfWeek
    {
        Domingo = 1,
        Segunda = 2,
        Terça = 4,
        Quarta = 8,
        Quinta = 16,
        Sexta = 32,
        Sábado = 64
    }
}
