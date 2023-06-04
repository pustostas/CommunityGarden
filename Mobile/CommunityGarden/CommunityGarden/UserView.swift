//
//  UserView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 03.06.2023.
//

import SwiftUI

struct UserView: View {
    var user:User
    var body: some View {
        ScrollView{
            VStack {
                if let profilePictureURL = user.profilePicture {
                    // Display the profile picture if available
                    AsyncImage(url: profilePictureURL ) { image in
                            image
                                .resizable()
                                .frame(width: 200,height: 200)
                                .clipShape(Circle())
                                .overlay {
                                    Circle().stroke(Color.accentColor, lineWidth: 2)
                                }
                        } placeholder: {
                            ProgressView()
                        }
                        .aspectRatio(3 / 2, contentMode: .fill)
                        .shadow(radius: 4)
                }
                
                Text(user.name)
                    .font(.title)
                    .fontWeight(.bold)
                    
                
                Text(user.firstName + " " + user.secondName)
                    .font(.title2)
                   
                DividerView()
                Text("Birth Date: \(user.birthDate)")
                    .font(.title2)
                    .padding(.bottom)
                    
                Text("Email: \(user.email)")
                    .font(.title2)
                DividerView()
                Text("Bio: \(user.bio)")
                    .font(.headline)
                
            }
        }
            .padding()
        }
}
