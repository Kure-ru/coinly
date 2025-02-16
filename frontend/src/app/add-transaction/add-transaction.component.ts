import { Component, Input, Output, EventEmitter } from '@angular/core';
import { SelectItem } from 'primeng/api';
import {Button} from 'primeng/button';
import {Dialog} from 'primeng/dialog';
import {InputText} from 'primeng/inputtext';
import {Select} from 'primeng/select';
import {FormsModule} from '@angular/forms';
import {DatePicker} from 'primeng/datepicker';

@Component({
  selector: 'app-add-transaction',
  templateUrl: './add-transaction.component.html',
  imports: [
    Button,
    Dialog,
    InputText,
    Select,
    FormsModule,
    DatePicker
  ]
})
export class AddTransactionComponent {
  @Input() visible: boolean = false;
  @Output() visibleChange = new EventEmitter<boolean>();
  @Input() onSave!: () => void;
  @Input() amount: number = 0.0;
  @Output() amountChange = new EventEmitter<number>();
  @Input() categoryLabels: SelectItem[] = [];
  @Output() categoryLabelsChange = new EventEmitter<SelectItem[]>();
  @Input() payee: string = '';
  @Output() payeeChange = new EventEmitter<string>();
  @Input() date: Date = new Date();
  @Output() dateChange = new EventEmitter<Date>();
  @Input() transactionTypes: SelectItem[] = [];
  @Input() type: SelectItem = {label: '', value: ''};
  @Output() typeChange = new EventEmitter<SelectItem>();
  @Input() category: { label: string, value: number } = { label: '', value: 0 };
  @Output() categoryChange = new EventEmitter<{ label: string, value: number }>();

  closeDialog() {
    this.visible = false;
    this.visibleChange.emit(this.visible);
  }

  updateAmount(newAmount: number) {
    this.amount = newAmount;
    this.amountChange.emit(this.amount);
  }

  updateCategory(newCategory: { label: string, value: number }) {
    this.category = newCategory;
    this.categoryChange.emit(this.category);
  }

  updateDate(newDate: Date) {
    this.date = newDate;
    this.dateChange.emit(this.date);
  }

  updatePayee(newPayee: string) {
    this.payee = newPayee;
    this.payeeChange.emit(this.payee);
  }

  updateType(newType: SelectItem) {
    this.type = newType;
    this.typeChange.emit(this.type);
  }
}
