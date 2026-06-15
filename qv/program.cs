using System;
using System.Numerics;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Contracts;
using Nethereum.ABI.FunctionEncoding.Attributes;

// 1. Định nghĩa các lớp DTO (Data Transfer Objects) để ánh xạ hàm Solidity sang C#
// Giả sử hợp đồng Solidity có hàm: function set(uint256 _value) public
// và hàm: function get() public view returns (uint256)

[Function("set", "bool")]
public class SetFunction : FunctionMessage
{
    [Parameter("uint256", "_value", 1)]
    public BigInteger Value { get; set; }
}

[Function("get", "uint256")]
public class GetFunction : FunctionMessage { }

// Lớp chứa thông tin triển khai (Deployment)
public class SimpleStorageDeployment : ContractDeploymentMessage
{
    // DÁN BYTECODE TỪ REMIX VÀO ĐÂY (Bỏ qua nếu hợp đồng đã deploy sẵn)
    public static string BYTECODE = "0x608060405234801561001057600080fd5b50..."; 

    public SimpleStorageDeployment() : base(BYTECODE) { }
}

class Program
{
    static async Task Main(string[] args)
    {
        // 2. Cấu hình kết nối
        // Thay thế bằng Private Key của bạn (Cẩn thận: Không chia sẻ key thật)
        var privateKey = "0xYOUR_PRIVATE_KEY_HERE"; 
        // Thay thế bằng RPC URL (Ví dụ: Infura, Alchemy, hoặc Localhost từ Remix)
        var rpcUrl = "https://sepolia.infura.io/v3/YOUR_PROJECT_ID"; 
        
        var account = new Account(privateKey);
        var web3 = new Web3(account, rpcUrl);

        Console.WriteLine("Bắt đầu kết nối Ethereum...");

        // --- TÙY CHỌN A: TRIỂN KHAI HỢP ĐỒNG MỚI TỪ REMIX ---
        Console.WriteLine("\n--- Đang triển khai hợp đồng mới ---");
        
        var deploymentMessage = new SimpleStorageDeployment();
        var deploymentHandler = web3.Eth.GetContractDeploymentHandler<SimpleStorageDeployment>();
        
        // Gửi giao dịch deploy và đợi biên lai (receipt)
        var receipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
        var contractAddress = receipt.ContractAddress;
        
        Console.WriteLine($"Hợp đồng đã triển khai tại: {contractAddress}");
        Console.WriteLine($"Hash giao dịch: {receipt.TransactionHash}");

        // --- TÙY CHỌN B: TƯƠNG TÁC VỚI HỢP ĐỒNG ĐÃ TRIỂN KHAI ---
        // Nếu bạn đã có địa chỉ hợp đồng từ Remix, hãy gán trực tiếp vào biến này
        // var contractAddress = "0xĐịa_Chỉ_Hợp_Đồng_Từ_Remix"; 

        Console.WriteLine("\n--- Đang tương tác với hợp đồng ---");

        // 3. Gọi hàm ghi (Transaction) - Hàm set(uint256)
        Console.WriteLine("Đang ghi dữ liệu (set value = 123)...");
        var setFunction = new SetFunction { Value = 123 };
        var transactionHandler = web3.Eth.GetContractTransactionHandler<SetFunction>();
        
        var txReceipt = await transactionHandler.SendRequestAndWaitForReceiptAsync(contractAddress, setFunction);
        Console.WriteLine($"Giao dịch thành công. Hash: {txReceipt.TransactionHash}");

        // 4. Gọi hàm đọc (Query/Call) - Hàm get()
        Console.WriteLine("Đang đọc dữ liệu (get value)...");
        var getFunction = new GetFunction();
        var queryHandler = web3.Eth.GetContractQueryHandler<GetFunction>();
        
        // Thực hiện gọi hàm và nhận kết quả dưới dạng BigInteger
        var result = await queryHandler.QueryAsync<BigInteger>(contractAddress, getFunction);
        
        Console.WriteLine($"Giá trị lưu trữ trên Blockchain là: {result}");
        Console.WriteLine("Hoàn tất quy trình.");
    }
}   