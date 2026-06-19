// SPDX-License-Identifier: MIT
pragma solidity ^0.8.35;

import "@openzeppelin/contracts/token/ERC20/ERC20.sol";
import "@openzeppelin/contracts/access/Ownable.sol";

// ──────────────────────────────────────────────────────────────
// BASE TOKEN - Không decimals (số nguyên)
// ──────────────────────────────────────────────────────────────
contract AssetToken is ERC20, Ownable {
    
    string public assetType; // "MonAn", "HangHoa", "ChoO"

    constructor(
        string memory name_,
        string memory symbol_,
        address initialOwner,
        uint256 initialSupply,
        string memory assetType_
    ) ERC20(name_, symbol_) Ownable(initialOwner) {
        assetType = assetType_;
        if (initialSupply > 0) {
            _mint(initialOwner, initialSupply);
        }
    }

    function mint(address to, uint256 amount) external onlyOwner {
        _mint(to, amount);
    }

    function burn(uint256 amount) external {
        _burn(msg.sender, amount);
    }
}

// ──────────────────────────────────────────────────────────────
// MASTER FACTORY - Quản lý cả 3 loại: Ăn, Hàng Hoá, Chỗ Ở
// ──────────────────────────────────────────────────────────────
contract AssetFactory is Ownable {
    
    address[] public allTokens;
    
    // Phân loại token
    mapping(address => string) public tokenType;           // "MonAn" | "HangHoa" | "ChoO"
    mapping(address => bool) public isTokenFromFactory;

    event TokenCreated(
        address indexed tokenAddress,
        string assetType,
        string name,
        string symbol,
        uint256 initialSupply
    );

    constructor() Ownable(msg.sender) {}

    /**
     * @dev Tạo token theo loại
     * @param assetType "MonAn", "HangHoa", hoặc "ChoO"
     */
    function createAssetToken(
        string calldata assetType,
        string calldata name,
        string calldata symbol,
        uint256 initialSupply
    ) external onlyOwner returns (address) {
        
        require(
            keccak256(bytes(assetType)) == keccak256(bytes("MonAn")) ||
            keccak256(bytes(assetType)) == keccak256(bytes("HangHoa")) ||
            keccak256(bytes(assetType)) == keccak256(bytes("ChoO")),
            "Invalid asset type"
        );

        AssetToken token = new AssetToken(
            name,
            symbol,
            msg.sender,
            initialSupply,
            assetType
        );

        address tokenAddr = address(token);
        
        allTokens.push(tokenAddr);
        isTokenFromFactory[tokenAddr] = true;
        tokenType[tokenAddr] = assetType;

        emit TokenCreated(tokenAddr, assetType, name, symbol, initialSupply);
        return tokenAddr;
    }

    // ────── Helper functions ──────

    function getAllTokens() external view returns (address[] memory) {
        return allTokens;
    }

    function getTokensByType(string calldata assetType) external view returns (address[] memory) {
        uint256 count = 0;
        for (uint256 i = 0; i < allTokens.length; i++) {
            if (keccak256(bytes(tokenType[allTokens[i]])) == keccak256(bytes(assetType))) {
                count++;
            }
        }

        address[] memory result = new address[](count);
        uint256 index = 0;
        for (uint256 i = 0; i < allTokens.length; i++) {
            if (keccak256(bytes(tokenType[allTokens[i]])) == keccak256(bytes(assetType))) {
                result[index] = allTokens[i];
                index++;
            }
        }
        return result;
    }

    function isValidToken(address tokenAddr) external view returns (bool) {
        return isTokenFromFactory[tokenAddr];
    }

    /**
     * @dev Mint từ xa qua Factory (tùy chọn)
     */
    function mintForToken(
        address tokenAddress,
        address to,
        uint256 amount
    ) external onlyOwner {
        require(isTokenFromFactory[tokenAddress], "Not from this factory");
        AssetToken(tokenAddress).mint(to, amount);
    }
}