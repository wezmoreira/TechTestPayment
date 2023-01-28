using Pottencial.Domain.Enums;

namespace Pottencial.Domain.Util;

public static class OrderStatusUtil
{
    public static EStatusOrder StatusOrder(EStatusOrder statusModel, EStatusOrder statusDb)
    {
        if (statusDb == EStatusOrder.AGUARDANDO_PAGAMENTO)
        {
            if (statusModel == EStatusOrder.PAGAMENTO_APROVADO)
                return EStatusOrder.PAGAMENTO_APROVADO;
            else if (statusModel == EStatusOrder.CANCELADA)
                return EStatusOrder.CANCELADA;
        }
        else if (statusDb == EStatusOrder.PAGAMENTO_APROVADO)
        {
            if (statusModel == EStatusOrder.ENVIADO_PARA_TRANSPORTADORA)
                return EStatusOrder.ENVIADO_PARA_TRANSPORTADORA;
            else if (statusModel == EStatusOrder.CANCELADA)
                return EStatusOrder.CANCELADA;
        }
        else if (statusDb == EStatusOrder.ENVIADO_PARA_TRANSPORTADORA)
            return EStatusOrder.ENTREGUE;
        
        return EStatusOrder.ERRO;
    }
}