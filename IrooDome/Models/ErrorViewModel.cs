// ����� �� ����� ���� �������
namespace IrooDome.Models
{
    // ����� ����� ErrorViewModel
    public class ErrorViewModel
    {
        // ������ ���� ���� �����, ���� ����� null
        public string? RequestId { get; set; }

        // ������ ������ ����� �� �� ����� �� ���� �����
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
