using Newtonsoft.Json;
using Xunit;

namespace Customer360.Event.Processor.Test
{
    public class EventCrmaCallService
    {
        [Fact]
        public void SampleJson()
        {
            dynamic sample = JsonConvert.SerializeObject(
                @"{'magic': 'atMSG', 'type': 'DT', 'headers': null, 'messageSchemaId': null, 'messageSchema': null, 'message': {'data': {'EVENTOATENDIMENTOID': '13234341', 'TIPOEVENTOATENDIMENTOID': 28, 'TIPOGRUPOEVENTOID': 3, 'TIPOIDENTIFICADOR': 'Inscri\u00E7\u00E3o', 'USUARIOID': 88976, 'DATAHORACRIACAO': '2018 - 09 - 04 14:14:11.897149', 'PESSOAID': '60024086', 'CPF': '84829931787', 'MATRICULAID': '11089342', 'INSCRICAOID': '1051044381546', 'ITEMCERTIFICADOAPOLICEID': null, 'PROTOCOLO': '04092018051508364', 'ATIVIDADE': null, 'LOGPROPRIEDADESMODIFICADAS': 'GAEAAB + LCAAAAAAABACr9slPt + LlqublUvI7tEvBM684uSjz8PLDi / OVrBSilZR0lAwNTA0NTEyMLQxNTcyUYnWAKp3zcwtSSw6vykvOTIQpMzDUN7DUNzIwtICocUksSVQISwUqyU3NK0GYZomqzC2 / KDdRISVVwTk / qSgx7 / ByuIFO + TmpJfkKTol5yYcXFmXmo6l3zSvLhJvqmpeSWpR6eDlUEYILlYcIGwAtySspykwqhfhQwdMF7ixTUwMDcyNjE6XYWl4uIAIAeB + yLxgBAAA = ', 'DataEvento': '2018 - 09 - 04 14:14:14.000000'}, 'beforeData': null, 'headers': {'operation': 'INSERT', 'changeSequence': '20180904171414290000000000089580073', 'timestamp': '2018 - 09 - 04T17: 14:14.294', 'streamPosition': '2018 - 09 - 04 - 14.14.43.448512AAAA', 'transactionId': '00000000000000000000000043355900'}}}");

            Assert.NotNull(sample);
            Assert.True(sample.type == "DT");
            Assert.True(sample.message.headers.operation == "INSERT");
        }
    }
}
