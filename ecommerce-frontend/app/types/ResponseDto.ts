export const enum UserRole {
  BUYER = "Buyer",
  SELLER = "Seller",
}

export interface BuyerProductResponseDto {
  id: string;
  sku: string;
  name: string;
  price: number;
  countInStock: number;
  description: string | null;
  images: string | null;
}

export interface BuyerCartItemResponseDto {
  id: string;
  sku: string;
  name: string;
  price: number;
  countInStock: number;
  description: string | null;
  images: string | null;
  countInCart: number;
}

export interface BuyerOrderResponseDto {
  orderId: string;
  orderValue: number;
  productCount: number;
  productId: string;
  productName: string;
  productSku: string;
  deliveryAddress: string;
}

export interface BuyerOrderResponseDto {
  orderId: string;
  orderValue: number;
  productCount: number;
  productId: string;
  productName: string;
  productSku: string;
  deliveryAddress: string;
}
