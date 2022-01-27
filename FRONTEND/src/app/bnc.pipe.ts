import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'bnc'
})
export class BncPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return value + ' lei';
  }

}
