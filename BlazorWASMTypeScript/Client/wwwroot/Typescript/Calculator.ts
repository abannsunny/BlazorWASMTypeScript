
import { InvokableFunction } from './models/InvokableFunctions';
import { NotificationService } from './models/NoficationService';

export class Calculator {
    public static Sum(notificationService: NotificationService, x: number, y: number) {
         notificationService.invokeMethodAsync(InvokableFunction.ReturnSum, x + y);
    }
}