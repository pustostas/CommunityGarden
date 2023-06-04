//
//  TestView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 04.06.2023.
//

import Foundation
import Alamofire
import SwiftUI

struct Test {
    
    struct ApiResponse: Decodable {
        var userId: Int
        var username: String
        var firstName: String
        var secondName: String
        var birthDate: String
        var email: String
        var bio: String
        var experdID: Int?
        var role: Int
        var passwordHash: String
        
    }
    
        
    static func login(email: String, password: String) {
        let parameters: Parameters = [
            "email": email,
            "passwordHash": password
        ]
        var string = email + "@@@" + password
        AF.request("https://communitygarden.azurewebsites.net/api/LoginApi/\(string)")
            .validate(statusCode: 200..<300)
            .responseDecodable(of: ApiResponse.self) { response in
                switch response.result {
                case .success(let apiResponse):
                    // Login successful, handle the response
                    print(apiResponse.userId)
                    print(apiResponse.secondName)
                    print(apiResponse.bio)
                    // Access other properties of ApiResponse

                case .failure(let error):
                    // Login failed, handle the error
                    print("Login failed: \(error)")
                }
            }
    }

}
