namespace Consultorio.Domain.Entity.OutPutDTOs
{
    public class ServicoOutputDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Duracao { get; set; }
    }
}
