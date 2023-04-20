pragma solidity ^0.8.0;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";
import "@openzeppelin/contracts/token/ERC721/extensions/ERC721URIStorage.sol";
import "@openzeppelin/contracts/access/Ownable.sol";
import "@openzeppelin/contracts/utils/structs/EnumerableSet.sol";
import "@openzeppelin/contracts/interfaces/IERC2981.sol";

contract ImprovedNFT is ERC721, ERC721URIStorage, Ownable, IERC2981 {
    using EnumerableSet for EnumerableSet.AddressSet;

    uint256 private _tokenIdCounter;
    uint256 private constant _royaltyBps = 1000; // 10% royalty
    uint256 public constant MAX_SUPPLY = 10000; // Maximum number of tokens that can be minted
    address private _royaltyReceiver;
    EnumerableSet.AddressSet private _minters;

    constructor(address royaltyReceiver) ERC721("ImprovedNFT", "INFT") {
        _tokenIdCounter = 0;
        _royaltyReceiver = royaltyReceiver;

        // Add the contract owner as an initial minter
        _minters.add(msg.sender);
    }

    modifier onlyMinter() {
        require(_minters.contains(msg.sender), "Not a minter");
        _;
    }

    function mintNFT(address to, string memory tokenURI) public onlyMinter {
        require(_tokenIdCounter < MAX_SUPPLY, "Minting cap reached");
        uint256 newTokenId = _tokenIdCounter;
        _safeMint(to, newTokenId);
        _setTokenURI(newTokenId, tokenURI);
        _tokenIdCounter = _tokenIdCounter + 1;

        emit NFTMinted(to, newTokenId, tokenURI);
    }

    function _burn(uint256 tokenId) internal override(ERC721, ERC721URIStorage) {
        super._burn(tokenId);
    }

    function tokenURI(uint256 tokenId) public view override(ERC721, ERC721URIStorage) returns (string memory) {
        return super.tokenURI(tokenId);
    }

    function supportsInterface(bytes4 interfaceId) public view override(ERC721, ERC721URIStorage, IERC165) returns (bool) {
        return interfaceId == type(IERC2981).interfaceId || super.supportsInterface(interfaceId);
    }

    function royaltyInfo(uint256 tokenId, uint256 salePrice) external view override returns (address receiver, uint256 royaltyAmount) {
        receiver = _royaltyReceiver;
        royaltyAmount = (salePrice * _royaltyBps) / 10000;
    }

    function addMinter(address minter) public onlyOwner {
        _minters.add(minter);
    }

    function removeMinter(address minter) public onlyOwner {
        _minters.remove(minter);
    }

    function isMinter(address minter) public view returns (bool) {
        return _minters.contains(minter);
    }

    event NFTMinted(address to, uint256 tokenId, string tokenURI);
}
