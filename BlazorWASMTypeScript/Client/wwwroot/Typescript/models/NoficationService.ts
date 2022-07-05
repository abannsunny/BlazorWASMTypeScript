export interface NotificationService<T = {}> {
    invokeMethodAsync(method: string, payload: T): void;
}