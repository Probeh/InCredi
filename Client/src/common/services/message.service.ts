import { ToastrService } from 'ngx-toastr'
import { Injectable } from '@angular/core'
import { MessageType } from '@enums/message.enum'

@Injectable({ providedIn: 'root' })
export class MessageService {
  // ======================================= //
  constructor(private service: ToastrService) {
    this.service.toastrConfig.autoDismiss       = true                ;
    this.service.toastrConfig.closeButton       = true                ;
    this.service.toastrConfig.easing            = 'ease-in-out'       ;
    this.service.toastrConfig.extendedTimeOut   = 1000                ;
    this.service.toastrConfig.maxOpened         = 2                   ;
    this.service.toastrConfig.newestOnTop       = false               ;
    this.service.toastrConfig.positionClass     = 'toast-bottom-right';
    this.service.toastrConfig.preventDuplicates = false               ;
    this.service.toastrConfig.progressAnimation = 'decreasing'        ;
    this.service.toastrConfig.progressBar       = true                ;
    this.service.toastrConfig.tapToDismiss      = true                ;
    this.service.toastrConfig.timeOut           = 1500                ;
  }
  // ======================================= //
  public show(title: string, message: string, type: MessageType = MessageType.Info) {
    switch (type) {
      case MessageType.Error:
        this.service.error(message, title);
        break;
      case MessageType.Info:
        this.service.info(message, title);
        break;
      case MessageType.Success:
        this.service.success(message, title);
        break;
      case MessageType.Warning:
        this.service.warning(message, title);
        break;
    }
  }
}
