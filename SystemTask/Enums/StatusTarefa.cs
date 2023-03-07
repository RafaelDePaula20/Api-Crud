using System.ComponentModel;

namespace SystemTask.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em adandamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3,
    }
}
