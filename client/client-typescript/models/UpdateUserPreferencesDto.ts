/* tslint:disable */
/* eslint-disable */
/**
 * ZPI API
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: all
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { exists, mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface UpdateUserPreferencesDto
 */
export interface UpdateUserPreferencesDto {
    /**
     * 
     * @type {string}
     * @memberof UpdateUserPreferencesDto
     */
    preferenceCurrency: string;
    /**
     * 
     * @type {boolean}
     * @memberof UpdateUserPreferencesDto
     */
    weeklyReports: boolean;
    /**
     * 
     * @type {boolean}
     * @memberof UpdateUserPreferencesDto
     */
    alertsOnEmail: boolean;
}

/**
 * Check if a given object implements the UpdateUserPreferencesDto interface.
 */
export function instanceOfUpdateUserPreferencesDto(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "preferenceCurrency" in value;
    isInstance = isInstance && "weeklyReports" in value;
    isInstance = isInstance && "alertsOnEmail" in value;

    return isInstance;
}

export function UpdateUserPreferencesDtoFromJSON(json: any): UpdateUserPreferencesDto {
    return UpdateUserPreferencesDtoFromJSONTyped(json, false);
}

export function UpdateUserPreferencesDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): UpdateUserPreferencesDto {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'preferenceCurrency': json['preferenceCurrency'],
        'weeklyReports': json['weeklyReports'],
        'alertsOnEmail': json['alertsOnEmail'],
    };
}

export function UpdateUserPreferencesDtoToJSON(value?: UpdateUserPreferencesDto | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'preferenceCurrency': value.preferenceCurrency,
        'weeklyReports': value.weeklyReports,
        'alertsOnEmail': value.alertsOnEmail,
    };
}
