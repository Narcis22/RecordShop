import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appHoverButton]'
})
export class HoverButtonDirective {

    constructor(
      public el: ElementRef,
    ) { }
  
    private highlight(color: string) {
      this.el.nativeElement.style.backgroundColor = color;
    }

    @HostListener('mouseenter') onMouseEnter() {
      this.highlight('dodgerblue');
    }
  
    @HostListener('mouseleave') onMouseLeave() {
      this.highlight('');
    }
  
}
  