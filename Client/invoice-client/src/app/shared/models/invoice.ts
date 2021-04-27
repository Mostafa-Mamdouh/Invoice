export interface ItemDto {
  itemCode: number;
  itemName: string;
  qty: number;
  price: number;
  invoiceId: number;
}

export interface IInvoiceEditor {
  invoiceId: number;
  invoiceDate: Date;
  paymentMethod: boolean;
  customer: string;
  description: string;
  itemDtos: ItemDto[];
}
