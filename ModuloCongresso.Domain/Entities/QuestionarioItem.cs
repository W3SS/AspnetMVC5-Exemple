namespace ModuloCongresso.Domain.Entities
{
    public class QuestionarioItem
    {
        public int QuestionarioItemId { get; set; }

        public int PerguntaId { get; set; }

        public string Resposta { get; set; }
    }
}