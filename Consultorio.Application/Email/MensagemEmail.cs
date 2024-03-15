using Consultorio.Domain.Entity;

namespace Consultorio.Application.Email
{
    public static class MensagemEmail
    {
        public static async Task<string> Mensagens(Servico servico, Paciente paciente, Atendimento atendimento, string assunto, string mensagem) => await
                $"Confirmação de Agendamento de consulta: {servico.Nome}." +
                $"Prezado(a), {paciente} <br> " +
                $"É com satisfação que informamos a confirmação do agendamento da sua consulta para o dia {atendimento.Inicio.Date.ToString("dd/MM/yyyy")} às {atendimento.Inicio.ToString("HH:mm")}.<br> " +
                $"A consulta será realizada em nosso consultório localizado na Rua dos Bobos, Nº 0 <br> " +
                $"Pedimos que chegue com pelo menos 15 minutos de antecedência para que possamos realizar o seu atendimento de forma pontual. Caso haja qualquer impedimento ou necessidade de reagendamento, pedimos a gentileza de entrar em contato conosco o mais breve possível.<br>" +
                $"Estamos à disposição para esclarecer qualquer dúvida que possa surgir. Agradecemos pela confiança em nossos serviços e estamos ansiosos para atendê-lo(a) em breve.<br> <br>" +
                $"Atenciosamente, <br>" +
                $"Clínica Médica <br>" +
                $"(86) 9 9011-2255";
    }
}
