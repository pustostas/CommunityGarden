//
//  User.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import Foundation

struct User: Codable, Hashable, Identifiable {
    var id: String
    var name: String
    var firstName: String
    var secondName: String
    var birthDate: String
    var profilePicture: URL?
    var email: String
    var bio: String
    var extertId: Int?
}
